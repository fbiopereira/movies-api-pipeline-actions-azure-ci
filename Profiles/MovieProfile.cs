using AutoMapper;
using movies_api_pipeline_actions_azure_ci.Dtos;
using movies_api_pipeline_actions_azure_ci.Models;

namespace movies_api_pipeline_actions_azure_ci.Profiles
{
    public class MovieProfile: Profile

    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
        }
    }
}
