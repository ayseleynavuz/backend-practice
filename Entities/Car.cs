namespace backend_practice.Entities
{
    public class Car : BaseEntity
    {
        public string CarName { get; set; }
        public int CarID { get; set; }
        public int wheels { get; set; }
        public bool? activeHeadlight { get; set; }
    }
}
