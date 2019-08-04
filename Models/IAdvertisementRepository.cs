using System.Linq;

namespace Raspertise.Models {

    public interface IAdvertisementRepository {

        IQueryable<Advertisement> Advertisements { get; }

    }

}