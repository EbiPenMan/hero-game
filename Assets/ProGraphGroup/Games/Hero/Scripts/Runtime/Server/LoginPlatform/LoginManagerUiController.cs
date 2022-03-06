using Cysharp.Threading.Tasks;
using ProGraphGroup.Games.Hero.Server.LoginPlatform.Base;
using ProGraphGroup.General.Utility;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProGraphGroup.Games.Hero.Server.LoginPlatform
{
    public class LoginManagerUiController : MonoBehaviourExtend
    {
        public GameObject rootNode;
        public GameObject loginPlatformTypesNode;
        public GameObject btnDeviceLogin;
        public GameObject btnEmailLogin;
        public GameObject btnCafeBazaarLogin;
        public GameObject loadingUi;
        public RTLTextMeshPro errorMessage;
        public Button btn_back;
        public Button btn_retry;

        private LoginPlatformType _selectedLoginPlatformType;

        public async UniTask<LoginPlatformType> SelectLoginPlatform()
        {
            btnDeviceLogin.SetActive(LoginManager.Instance.activeLoginPlatformType.HasFlag(LoginPlatformType.DeviceId));
            btnEmailLogin.SetActive(LoginManager.Instance.activeLoginPlatformType.HasFlag(LoginPlatformType.Email));
            btnCafeBazaarLogin.SetActive(
                LoginManager.Instance.activeLoginPlatformType.HasFlag(LoginPlatformType.CafeBazaar));

            loginPlatformTypesNode.SetActive(true);
            await UniTask.WaitUntilValueChanged(this, x => x._selectedLoginPlatformType);
            return _selectedLoginPlatformType;
        }

        public void OnSelectedLoginPlatformType(int loginPlatformType)
        {
            _selectedLoginPlatformType = (LoginPlatformType) loginPlatformType;
        }

        public void InitShowUi()
        {
            rootNode.SetActive(true);
            loadingUi.SetActive(true);
            loginPlatformTypesNode.SetActive(false);
        }
        public void InitHideUi()
        {
            rootNode.SetActive(false);
            loadingUi.SetActive(false);
            loginPlatformTypesNode.SetActive(false);
        }
    }
}