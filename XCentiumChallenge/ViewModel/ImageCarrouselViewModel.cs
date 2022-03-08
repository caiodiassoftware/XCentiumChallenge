using System.Collections.Generic;
using System.Linq;
using XCentiumChallenge.Extensions;

namespace XCentiumChallenge.ViewModel
{
    public class ImageCarrouselViewModel
    {
        private IList<string> Images { get; set; }

        public ImageCarrouselViewModel() { }

        public ImageCarrouselViewModel(IEnumerable<string> images)
        {
            if (images != null)
            {
                Images = images.ToList();
            }
        }

        public int GetTotal()
        {
            return Images.Count();
        }

        public IList<string> GetImages()
        {
            return Images.Where(x => ValidateImage(x)).ToList();
        }

        private bool ValidateImage(string img)
        {
            if (img.IsBase64String())
            {
                return false;
            }

            if (!img.ValidUrl())
            {
                return false;
            }

            return true;
        }

        public bool HasImages()
        {
            return Images != null && Images.Any();
        }
    }
}