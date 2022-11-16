using FStoreAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStoreAppLibrary.Data_Layer.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool DeleteMember(int memberId) => MemberDBContext.Instance.Delete(memberId);

        public Member GetMemberById(int memberId) => MemberDBContext.Instance.GetMemberById(memberId);

        public List<Member> GetMembers() => MemberDBContext.Instance.GetMembers();

        public bool InsertMember(Member member) => MemberDBContext.Instance.Insert(member);

        public bool UpdateMember(Member member) => MemberDBContext.Instance.Update(member);

        public Member CheckExistUser(string email, string password) => MemberDBContext.Instance.Exist(email, password);  

    }
}
