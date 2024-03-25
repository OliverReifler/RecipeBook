using MauiLib.Interfaces;
using MauiLib.Models;

namespace MauiLib.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagService(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            if (_tagRepository.GetAll().Any(x => x.Title == tag.Title))
            {
                throw new ArgumentException("Tag allready exists");
            }
            await _tagRepository.CreateAsync(tag);
            await _tagRepository.SaveChangesAsync();
            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return _tagRepository.GetAll().ToList();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _tagRepository.GetByIdAsync(id) ?? throw new ArgumentException("Tag Id Doesnt Exist/not found");
        }
    }
}