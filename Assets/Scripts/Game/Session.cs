using UnityEngine;


namespace Assets.Scripts.Game
{
    [DefaultExecutionOrder(-2)]
    public class Session : Singleton<Session>
    {
        public GamePlayManager GamePlayManager { get; set; }
    }
}
