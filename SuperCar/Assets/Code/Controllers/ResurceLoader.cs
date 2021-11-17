using UnityEngine;

public static class ResurceLoader 
{
    public static Sprite LoadSprite(ResurcePath path)
    {
        return Resources.Load<Sprite>(path.PathResurce);
    }

    public static GameObject LoadPrefab(ResurcePath path)
    {
        return Resources.Load<GameObject>(path.PathResurce);
    }
}
