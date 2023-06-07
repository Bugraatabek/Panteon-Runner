using UnityEngine;

public interface IPaintable
{
    public bool IHaveBeenPainted();
    public void PaintMe(Color color);
}
