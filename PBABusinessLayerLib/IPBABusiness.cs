using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBAExceptionLib;
using PBAEntitiesLayerLib;

namespace PBABusinessLayerLib
{
    public interface IPBABusiness
    {
        List<ContactCategory> GetAllcategoryNames();
        void AddContactCategory(ContactCategory cat);
        List<Contact> GetAllContactsById(int id);
        void AddContact(Contact contact);
        void DeleteContactById(int id);
        void DeleteCategoryById(int id);
        void UpdateContactById(Contact contact);
        void UpdateCategoryById(ContactCategory cat);
    }
}
