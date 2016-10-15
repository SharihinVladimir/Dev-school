using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstLikeApp.Model
{
    public interface I_DataLayer
    {
        C_User AddUser(C_User User);
        C_Post AddPost(C_Post Post);
        C_Comment AddComment(C_Comment Comment);
        C_Hashtag AddHashtag(C_Hashtag Hashtag);
        C_Like AddLike(C_Like Like);
        C_Mark AddMark(C_Mark Mark);
        C_Reference AddReference(C_Reference Reference);

        C_User GetUser(Guid User_ID);
        C_Post GetPost(Guid Post_ID);
        C_Comment GetComment(Guid Comment_ID);
        C_Hashtag GetHashtag(Guid Hashtag_ID);
        C_Like GetLike(Guid Like_ID);
        C_Mark GetMark(Guid Mark_ID);
        C_Reference GetReference(Guid Reference_ID);

        int DeleteUser(Guid User_ID);
        int DeletePost(Guid Post_ID);
        int DeleteComment(Guid Comment_ID);
        int DeleteHashtag(Guid Hashtag_ID);
        int DeleteLike(Guid Like_ID);
        int DeleteMark(Guid Mark_ID);
        int DeleteReference(Guid Reference_ID);
    }
}
