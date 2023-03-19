namespace Model.VO
{
    public class EnemyVO : TankVO
    {
        private string nameData = "Player";
        public EnemyVO()
        {
            LoadData(nameData);
        }
    }
}
