namespace CashingNet.Domain.Entities
{
    public class Example
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public DateTime Created { get; set; }


        public Example Clone()
        {
            var obj = (Example)MemberwiseClone();
            obj.Sequence += 1;
            obj.Created = obj.Created.AddDays(1);
            return obj;
        }
    }
}
