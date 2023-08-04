namespace Web_LuyenLai.Model
{
    public class Product : ProductModel
    {
        public Guid Id { get; set; }
        
    }
    public class ProductModel 
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
