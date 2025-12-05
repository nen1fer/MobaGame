using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public interface INeedTarget
    {
        float GetViewDistance();
        void SetPotentialTargets(List<Unit> potentialTargets);
    }

}
