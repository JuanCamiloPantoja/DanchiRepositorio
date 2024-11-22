using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class ChatInternoRepository : IChatInternoRepository
    {
        private readonly Danchi_Context context;

        public ChatInternoRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<ChatInterno>> GetChatInterno()
        {
            var data = await context.chatInterno.ToListAsync();
            return data;
        }

        public async Task<ChatInterno> GetChatInternoById(int id)
        {
            var data = await context.chatInterno.Where(x => x.IdAdministrador == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<ChatInterno> GetChatInternoByName(int IdResidente)
        {
            var data = await context.chatInterno.Where(x => x.IdResidente == IdResidente).FirstOrDefaultAsync();
            return data;
        }
        public async Task<ChatInterno> GetChatInternoByName(string Mensaje)
        {
            var data = await context.chatInterno.Where(x => x.Mensaje == Mensaje).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostChatInterno(ChatInterno chatInterno)
        {
            await context.chatInterno.AddAsync(chatInterno);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutChatInterno(ChatInterno chatInterno)
        {
            context.chatInterno.Update(chatInterno);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteChatInterno(ChatInterno chatInterno)
        {
            context.chatInterno.Remove(chatInterno);
            await context.SaveAsync();
            return true;
        }
    }
}