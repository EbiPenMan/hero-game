using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

namespace ProGraphGroup.Packages.PackageManagerExtension
{
    [InitializeOnLoad]
    public class ExtentionEditorUi
    {
        private static string text = "Packages Normal";
        private static string tooltip = "All packages in your project is up to dated.";
        private static Color color = Color.green;
        private static ListRequest Request;
        private static bool isOk = true;
        private static bool inited = false;
        private static string packageNameToSelect = "";

        [InitializeOnLoadMethod]
        static void SubscribeToEvent()
        {
            Events.registeredPackages += RegisteredPackagesEventHandler;
        }

        static void RegisteredPackagesEventHandler(PackageRegistrationEventArgs packageRegistrationEventArgs)
        {
            Check();
        }


        static ExtentionEditorUi()
        {
            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
        }

        static void OnToolbarGUI()
        {
            if (!inited)
                Check();
            GUILayout.FlexibleSpace();

            GUI.contentColor = color;

            if (GUILayout.Button(new GUIContent(text, tooltip), ToolbarStyles.commandButtonStyle))
            {
                if (isOk)
                {
                    Check();
                }
                else
                {
                    UnityEditor.PackageManager.UI.Window.Open(packageNameToSelect);
                }
            }
        }

        static void Check()
        {
            inited = true;
            Request = Client.List(); // List packages installed for the project
            EditorApplication.update += Progress;
        }

        static void Progress()
        {
            if (Request.IsCompleted)
            {
                if (Request.Status == StatusCode.Success)
                {
                    bool notOk = false;
                    tooltip = "                                                           " +
                              System.Environment.NewLine;

                    packageNameToSelect = "";
                    
                    foreach (var package in Request.Result)
                    {
                        if (package.versions.verified != "" && package.versions.verified != package.version)
                        {
                            notOk = true;
                            tooltip += "Name: " + package.displayName + System.Environment.NewLine;
                            tooltip += " Current: " + package.version + System.Environment.NewLine;
                            tooltip += " Latest: " + package.versions.verified + System.Environment.NewLine+ System.Environment.NewLine;
                            if (packageNameToSelect == "")
                            {
                                packageNameToSelect = package.name;
                            }
                        }
                        else if (package.versions.verified == "" && package.versions.latestCompatible != "" && package.versions.latestCompatible != package.version)
                        {
                            notOk = true;
                            tooltip += "Name: " + package.displayName + System.Environment.NewLine;
                            tooltip += " Current: " + package.version + System.Environment.NewLine;
                            tooltip += " Latest: " + package.versions.latestCompatible + System.Environment.NewLine+ System.Environment.NewLine;
                            if (packageNameToSelect == "")
                            {
                                packageNameToSelect = package.name;
                            }
                        }
                        else if (package.versions.verified == "" &&  package.versions.latestCompatible == "" &&
                                 package.versions.latest != "" && package.versions.latest != package.version)
                        {
                            notOk = true;
                            tooltip += "Name: " + package.displayName + System.Environment.NewLine;
                            tooltip += " Current: " + package.version + System.Environment.NewLine;
                            tooltip += " Latest: " + package.versions.latest + System.Environment.NewLine+ System.Environment.NewLine;
                            if (packageNameToSelect == "")
                            {
                                packageNameToSelect = package.name;
                            }
                        } 
                    }
                    
                    if (notOk)
                    {
                        isOk = false;
                        color = Color.red;
                        text = "Packages should be updated";
                    }
                    else
                    {
                        isOk = true;
                        color = Color.green;
                        text = "Packages are updated";
                        tooltip = "All packages in your project is up to dated.";
                    }

                    // OnToolbarGUI();
                }
                else if (Request.Status >= StatusCode.Failure)
                    Debug.Log(Request.Error.message);

                EditorApplication.update -= Progress;
            }
            
        }
    }


    static class ToolbarStyles
    {
        public static readonly GUIStyle commandButtonStyle;

        static ToolbarStyles()
        {
            commandButtonStyle = new GUIStyle("Command")
            {
                fontSize = 16,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold,
                fixedWidth = 350.0f
            };
        }
    }
}