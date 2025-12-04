using System.Collections.Generic;

public interface INeedTarget
{
    float SetViewDistance();
    void SetPotentialTargets(List<Unit> potentialTargets);
}
