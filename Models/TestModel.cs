namespace BackendApp.Models
{
     public class TestModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<TestOptions> Options { get; set; }
    }

    // public class TestOptions
    // {
    //     public int Id { get; set; }
    //     public string Option { get; set; }
    //     public bool IsCorrect { get; set; }
    // }
}
