

using UnityEngine;
namespace ChestSystem.chest
{
    [RequireComponent(typeof(ChestView))]
    public class State : MonoBehaviour
    {
        protected ChestView chestView;

        protected virtual void Awake()
        {
            chestView = GetComponent<ChestView>();
       }

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }


        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        public virtual void OnChestClick() { }

        public virtual void Tick() { }
    }

}
