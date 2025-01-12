using Application.Forum.Dtos.Channel;
using Application.Shared;
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

        public async Task<ApiResponse<>> GetChannelsAsync(Dto dto)
        {
           // to do implementation here
        }

        public async Task<ApiResponse<CreateResponseDto>> CreateChannelAsync(CreateRequestDto dto)
        {
            var existingChannel = _channelRepository.GetByNameAsync(dto.ChannelName);

            if(existingChannel != null)
            {
                return ApiResponse<CreateResponseDto>.FailureResponse("Já existe um canal com esse nome!");
            }

            var newChannel = new Channel(
                dto.CreatorId,
                new ChannelName(dto.ChannelName),
                new ChannelDescription(dto.ChannelDescription)
            );

            await _channelRepository.CreateAsync(newChannel);

            var channelResponse = new CreateResponseDto 
            {
                ChannelId = newChannel.ChannelId
            };

            return ApiResponse<CreateResponseDto>.SuccessResponse(channelResponse);
        }

        public async Task<ApiResponse<string>> UpdateChannelDescriptionAsync(UpdateDescriptionRequestDto dto)
        {
            var existingChannel = await _channelRepository.GetByIdAsync(dto.ChannelId);

            if(existingChannel == null)
            {
                return ApiResponse<string>.FailureResponse("Canal não existe!");
            }

            if(dto.UpdatedBy != existingChannel.CreatorId)
            {
                return ApiResponse<string>.FailureResponse("Você não tem permissão para editar esse canal!");
            }

            var channelDescription = new ChannelDescription(dto.ChannelDescription);
            existingChannel.UpdateDescription(channelDescription);
            await _channelRepository.UpdateAsync(existingChannel);

            return ApiResponse<string>.SuccessResponse(null);
        }

        public async Task<ApiResponse<string>> UpdateChannelProfilePictureAsync(UpdateProfilePictureRequestDto dto)
        {
            var existingChannel = await _channelRepository.GetByIdAsync(dto.ChannelId);

            if(existingChannel == null)
            {
                return ApiResponse<string>.FailureResponse("Canal não existe!");
            }

            if(dto.UpdatedBy != existingChannel.CreatorId)
            {
                return ApiResponse<string>.FailureResponse("Você não tem permissão para editar esse canal!");
            }

            existingChannel.UpdateProfilePicture(dto.PictureURL);
            await _channelRepository.UpdateAsync(existingChannel);

            return ApiResponse<string>.SuccessResponse(null);
        }

        public async Task<ApiResponse<string>> DeleteChannelAsync(DeleteRequestDto dto)
        {
            var existingChannel = await _channelRepository.GetByIdAsync(dto.ChannelId);

            if(existingChannel == null)
            {
                return ApiResponse<string>.FailureResponse("Canal não existe!");
            }

            if(dto.DeletedBy != existingChannel.CreatorId)
            {
                return ApiResponse<string>.FailureResponse("Você não tem permissão para deletar esse canal!");
            }

            await _channelRepository.DeleteAsync(existingChannel);
            return ApiResponse<string>.SuccessResponse(null);
        }
    }
}