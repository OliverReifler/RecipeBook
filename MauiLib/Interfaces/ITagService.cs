using MauiLib.Models;

namespace MauiLib.Interfaces
{
    public interface ITagService
    {
        Task<Tag> CreateTagAsync(Tag tag);

        Task<IEnumerable<Tag>> GetAllTagsAsync();

        Task<Tag> GetByIdAsync(int id);
    }
}