namespace Model.VO
{
    public class PlayerVO : TankVO
    {
        private string nameData = "Enemy";
        public PlayerVO()
        {
            LoadData(nameData);
        }
    }
}
