using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATG.BusinessObject;

namespace POPS.ATG.Utilities.Data
{
    public class FileUpload
    {
        //public List<BO_FileAttachFields> GetFileAttribs()
        //{
        //    List<BO_FileAttachFields> files = new List<BO_FileAttachFields>();

        //    using ( FileUploadDBDataContext db = new FileUploadDBDataContext( ConfigurationManager.ConnectionStrings["FileUploadDBStr"].ConnectionString ) )
        //    {

        //        var filesDal = from fs in db.FILE_ATTACHes
        //                       select new { fs.FILE_ATTACH_ID, fs.ATTACH_FILENAME, fs.FILE_SIZE };

        //        foreach ( var fs in filesDal )
        //        {
        //            FileAttribs fsdc = new FileAttribs();
        //            fsdc.FILE_ATTACH_ID = fs.FILE_ATTACH_ID;
        //            fsdc.ATTACH_FILENAME = fs.ATTACH_FILENAME;
        //            fsdc.FILE_SIZE = fs.FILE_SIZE;
        //            //  fsdc.FileBinary = fs.FileBinary.ToArray();
        //            files.Add( fsdc );
        //        }
        //    }

        //    return files;
        //}

        //public FileComplete GetFilesById( decimal? id )
        //{
        //    FileComplete fsdc = new FileComplete();

        //    using ( FileUploadDBDataContext db = new FileUploadDBDataContext( ConfigurationManager.ConnectionStrings["FileUploadDBStr"].ConnectionString ) )
        //    {

        //        FILE_ATTACH filesDal = ( from fs in db.FILE_ATTACHes
        //                                 where fs.FILE_ATTACH_ID == id
        //                                 select fs ).FirstOrDefault();

        //        fsdc.FILE_ATTACH_ID = filesDal.FILE_ATTACH_ID;
        //        fsdc.ATTACH_FILENAME = filesDal.ATTACH_FILENAME;
        //        fsdc.FILE_SIZE = filesDal.FILE_SIZE;
        //        fsdc.CONTENT_TYPE = filesDal.CONTENT_TYPE;
        //        fsdc.ATTACHMENT = filesDal.ATTACHMENT.ToArray();

        //    }

        //    return fsdc;
        //}

        //public decimal? UpdateFile( FileComplete file )
        //{
        //    decimal? fileId = null;
        //    FILE_ATTACH fileStorage = new FILE_ATTACH();
        //    bool fileExists = false;

        //    using ( FileUploadDBDataContext db = new FileUploadDBDataContext( ConfigurationManager.ConnectionStrings["FileUploadDBStr"].ConnectionString ) )
        //    {

        //        if ( file.FILE_ATTACH_ID.HasValue )
        //        {
        //            fileStorage = ( from fs in db.FILE_ATTACHes
        //                            where fs.FILE_ATTACH_ID == file.FILE_ATTACH_ID.Value
        //                            select fs ).FirstOrDefault();

        //            fileExists = true;

        //        }


        //        fileStorage.ATTACH_FILENAME = file.ATTACH_FILENAME;
        //        fileStorage.FILE_SIZE = file.FILE_SIZE;
        //        fileStorage.CONTENT_TYPE = file.CONTENT_TYPE;
        //        fileStorage.ATTACH_DESCRIPTION = file.ATTACH_DESCRIPTION;
        //        fileStorage.ATTACH_PARENT_ID = 999999;
        //        fileStorage.ATTACH_PARENT_ID_TYPE = "APPLICATION";

        //        fileStorage.ATTACHMENT = new System.Data.Linq.Binary( file.ATTACHMENT );

        //        if ( !fileExists )
        //        {
        //            db.FILE_ATTACHes.InsertOnSubmit( fileStorage );
        //        }

        //        db.SubmitChanges();

        //        fileId = fileStorage.FILE_ATTACH_ID;
        //    }

        //    return fileId;
        //}

        //public void DeleteFile( decimal? id )
        //{
        //    using ( FileUploadDBDataContext db = new FileUploadDBDataContext( ConfigurationManager.ConnectionStrings["FileUploadDBStr"].ConnectionString ) )
        //    {
        //        var file = ( from fs in db.FILE_ATTACHes
        //                     where fs.FILE_ATTACH_ID == id
        //                     select fs ).FirstOrDefault();

        //        if ( file != null )
        //        {
        //            db.FILE_ATTACHes.DeleteOnSubmit( file );
        //            db.SubmitChanges();
        //        }

        //    }
        //}
    }
}
