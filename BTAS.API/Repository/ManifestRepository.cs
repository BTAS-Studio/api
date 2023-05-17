using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ManifestRepository : IRepository<tbl_manifestDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;

        public ManifestRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all manifested records
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_manifestDto>> GetAllAsync()
        {
            IEnumerable<tbl_manifest> _list = await _context.tbl_manifests.ToListAsync();
            return _mapper.Map<List<tbl_manifestDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single manifested record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_manifestDto> GetByIdAsync(int id)
        {

            tbl_manifest manifest = await _context.tbl_manifests.FirstOrDefaultAsync(x => x.idtbl_manifest == id);
            return _mapper.Map<tbl_manifestDto>(manifest);

        }

        /// <summary>
        /// Creates nee manifested record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_manifestDto> CreateUpdateAsync(tbl_manifestDto entity)
        {
            try
            {
                tbl_manifest manifest = _mapper.Map<tbl_manifestDto, tbl_manifest>(entity);
                if (manifest.idtbl_manifest > 0)
                {
                    _context.tbl_manifests.Update(manifest);
                }
                else
                {
                    _context.tbl_manifests.Add(manifest);
                }
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_manifest, tbl_manifestDto>(manifest);
            }
            catch(Exception ex)
            {
                return entity;
            }
            
        }

        /// <summary>
        /// Deletes existing manifested record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_manifest manifest = await _context.tbl_manifests.FirstOrDefaultAsync(x => x.idtbl_manifest == id);
                if (manifest == null)
                {
                    return false;
                }
                _context.tbl_manifests.Remove(manifest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves consignment and load details to populate manifest template for XML generation
        /// </summary>
        /// <param name="reference">Tracking number</param>
        /// <param name="carrierId">Parcel's carrier id</param>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_xml_templateDto>> GetConsignmentDetailsAsync(string reference, string carrierId)
        {
            string StoredProc = "call PrepareManifest(" +
            "'" + reference + "','" + carrierId + "')";
            try
            {
                var result = await _context.Set<tbl_xml_template>().FromSqlRaw(StoredProc).ToListAsync<tbl_xml_template>();
                return _mapper.Map<IEnumerable<tbl_xml_templateDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Updates tbl_carrier_api_manifestId from tbl_carrier_api_response with the created manifest record id
        /// </summary>
        /// <param name="manifestId">Generated manifest id</param>
        /// <param name="reference">Tracking number</param>
        /// <returns></returns>
        public async Task<object> UpdateManifestAsync(int manifestId, string reference)
        {
            var result = await _context.tbl_carrier_api_responses.FirstOrDefaultAsync(x => x.tbl_carrier_api_trackingRef == reference);
            if (result != null)
            {
                result.tbl_carrier_api_manifestId = manifestId;
                
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<object> UpdateManifestAsync(int manifestId, DateTime sentDate)
        {
            var result = await _context.tbl_manifests.FirstOrDefaultAsync(x => x.idtbl_manifest == manifestId);
            if (result != null)
            {
                result.tbl_manifest_sent_date = sentDate;

                await _context.SaveChangesAsync();
            }

            return result;
        }

        /// <summary>
        /// Sends the generated XML thru SFTP
        /// </summary>
        /// <param name="filename">XML filename</param>
        /// <param name="host">SFTP host address</param>
        /// <param name="username">SFTP username</param>
        /// <param name="password">SFTP password</param>
        /// <returns></returns>
        public bool SendXmlToSftp(string filename, string host, string username, string password)
        {
            try
            {
                using (SftpClient client = new SftpClient(host, 22, username, password))
                {
                    client.Connect();

                    // client.ChangeDirectory(destination);

                    using (FileStream fs = new FileStream(filename, FileMode.Open))

                    {

                        client.BufferSize = 4 * 1024;

                        client.UploadFile(fs, Path.GetFileName(filename));

                    }

                }


                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Checks if parameter filename already exist
        /// </summary>
        /// <param name="path">File location to check</param>
        /// <returns></returns>
        public bool IsFileExist(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            return true;
        }

        public Task<IEnumerable<tbl_manifestDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_manifestDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_manifestDto>> GetAllAsyncWithChildren(searchFilter<tbl_manifestDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
