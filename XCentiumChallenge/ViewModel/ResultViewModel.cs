using System.Linq;

namespace XCentiumChallenge.ViewModel
{
    public class ResultViewModel<T>
    {
        public T Model { get; set; }

        public string[] Errors { get; set; }

        public ResultViewModel(string[] errors = null)
        {
            Errors = errors;
        }

        public ResultViewModel(T model, string[] errors = null) : this(errors)
        {
            Model = model;
        }

        public bool HasModel()
        {
            return Model != null;
        }

        public bool HasErrors()
        {
            return Errors != null && Errors.Any();
        }
    }
}