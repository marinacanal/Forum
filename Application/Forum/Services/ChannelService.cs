using Application.Forum.Dtos;
using Domain.Forum.Entities;
using Domain.Forum.ValueObjects;
using Infrastructure.Repositories.Forum;

namespace Application.Services.Forum
{
    public class ChannelService
    {
        private readonly ChannelRepository _channelRepository;

        public ChannelService(ChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public async Task<CreateChannelResponseDto> CreateChannelAsync(CreateChannelRequestDto dto)
        {
            var existingChannel = _channelRepository.GetByNameAsync(dto.ChannelName);

            if(existingChannel != null)
            {
                return new CreateChannelResponseDto {
                    IsSuccessful = false,
                    ErrorMessage = "Já existe um canal com esse nome!"
                };
            }

            var newChannel = new Channel(
                dto.CreatorId,
                new ChannelName(dto.ChannelName),
                new ChannelDescription(dto.ChannelDescription)
            );

            await _channelRepository.CreateAsync(newChannel);

            return new CreateChannelResponseDto {
                IsSuccessful = true,
                ChannelId = newChannel.ChannelId,
                CreatedAt = newChannel.CreatedAt
            };
        }
    }
}