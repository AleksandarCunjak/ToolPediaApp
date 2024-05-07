using AutoMapper;
using ToolPedia.Application.Tools.Models.Requests;
using ToolPedia.Application.Tools.Models.Responses;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Api.Mappings
{
    public class ToolProfile : Profile
    {
        public ToolProfile()
        {
            CreateMap<CreateToolRequest, Tool>();
            CreateMap<UpdateToolRequest, Tool>();
            CreateMap<Tool, ToolResponse>();
            //CreateMap<List<Tool>, ToolResponseList>().ConvertUsing<ToolListToResponseListConverter>();
        }
        //public class ToolListToResponseListConverter : ITypeConverter<List<Tool>, ToolResponseList>
        //{
        //    public ToolResponseList Convert(List<Tool> source, ToolResponseList destination, ResolutionContext context)
        //    {
        //        var toolResponses = context.Mapper.Map<List<ToolResponse>>(source);

        //        return new ToolResponseList
        //        {
        //            Tools = toolResponses,
        //            Total = source.Count
        //        };
        //    }
        //}
    }
}
