using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Data;
using DashApi.Dtos.Chat;
using DashApi.Interfaces;
using DashApi.Mappers;
using DashApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashApi.Repository
{
    public class ChatRepo : IChatRepo
    {
        private readonly DashDbContext _context;

        public ChatRepo(DashDbContext context){
            _context = context;
        }

        public async Task<List<Chat>> GetAllAsync(){
            return await _context.Chat.Include(m => m.Messages).ToListAsync();
        }


        public async Task<Chat?> GetByIdAsync(int id){
            return await _context.Chat.Include(m => m.Messages).FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<Chat> CreateChatAsync(Chat chat){
            await _context.Chat.AddAsync(chat);
            await _context.SaveChangesAsync();
            return chat;
        }


        public async Task<Chat?> EditChatAsync(int id, Chat dto)
        {
            var chat = await _context.Chat.FindAsync(id);

            if(chat == null){ return null; }

            chat.ChatName = dto.ChatName;
            await _context.SaveChangesAsync();

            return chat;
        }


        public async Task<Chat?> DeleteChatAsync(int id)
        {
            var chat = await _context.Chat.FirstOrDefaultAsync(i => i.Id == id);

            if(chat == null){ return null; }

            _context.Chat.Remove(chat);
            await _context.SaveChangesAsync();

            return chat;
        }


        public async Task<bool> ChatExists(int id)
        {
            return await _context.Chat.AnyAsync(s => s.Id == id);
        }
    }
}