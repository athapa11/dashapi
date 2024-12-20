using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Dtos.Message;
using DashApi.Models;
using DashApi.Queryables;

namespace DashApi.Interfaces
{
    public interface IMessageRepo
    {
        Task<List<Message>> GetAllAsync(MessageQuery query);

        Task<Message?> GetByIdAsync(int id);

        Task<Message> CreateMessageAsync(Message message);

        Task<Message?> EditMessageAsync(int id, Message dto);

        Task<Message?> DeleteMessageAsync(int id);
    }
}