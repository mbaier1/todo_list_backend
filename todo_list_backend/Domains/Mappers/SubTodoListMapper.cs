using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Mappers.Interfaces;
using todo_list_backend.DTOs;

namespace todo_list_backend.Domains.Mappers
{
    public class SubTodoListMapper : ISubTodoListMapper
    {
        public List<SubTodoItemDto> ToSubTodoItemDtos(List<SubTodoItem> subTodoItems)
        {
            var subTodoItemDtos = new List<SubTodoItemDto>();

            subTodoItems.ForEach(sub =>
            {
                subTodoItemDtos.Add(new SubTodoItemDto
                {
                    Id = sub.Id.ToString(),
                    Description = sub.Description,
                    AdditionalDetails = sub.AdditionalDetails,
                    AreThereAdditionalDetails = !string.IsNullOrEmpty(sub.AdditionalDetails),
                    SubTodoIsOverdue = sub.SubTodoIsOverdue,
                    SubTodoIsComplete = sub.SubTodoIsComplete,
                });
            });

            return subTodoItemDtos;
        }
    }
}
