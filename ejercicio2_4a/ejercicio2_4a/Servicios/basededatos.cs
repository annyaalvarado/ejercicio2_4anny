using ejercicio2_4a.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2_4a.Servicios
{
    public class basededatos
    {
        readonly SQLiteAsyncConnection dbase;

        public basededatos(string path)
        {
            dbase = new SQLiteAsyncConnection(path);

            dbase.CreateTableAsync<videoplayer>();
        }

        public basededatos()
        {
        }

        #region OperacionesVideo
        //CREATE
        public Task<int> insertUpdateVideo(videoplayer video)
        {
            if (video.Id != 0)
            {
                return dbase.UpdateAsync(video);
            }
            else
            {
                return dbase.InsertAsync(video);
            }
        }

        //READ
        public Task<List<videoplayer>> getListVideo()
        {
            return dbase.Table<videoplayer>().ToListAsync();
        }

        public Task<videoplayer> getVideo(int id)
        {
            return dbase.Table<videoplayer>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //DELETE
        public Task<int> deleteVideo(videoplayer video)
        {
            return dbase.DeleteAsync(video);
        }

        #endregion OperacionesVideo

    }
}

