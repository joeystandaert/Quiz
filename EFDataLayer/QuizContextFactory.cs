using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer
{
    public  class QuizContextFactory
    {
        private readonly DbContextOptions _option;
        private readonly string _connectionString;

        public QuizContextFactory(DbContextOptions option, string connectionString)
        {
            _option = option;
            _connectionString = connectionString;
        }

        public QuizContext Create()
        {
            return new QuizContext(_option, _connectionString);
        }
    }
}
