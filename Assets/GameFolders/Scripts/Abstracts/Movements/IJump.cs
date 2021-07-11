namespace MagaraGameJam.Abstracts.Movements
{
    public interface IJump
    {
        void Jump(float jumpForce);
        bool IsFlying { get; set; }
    }
}