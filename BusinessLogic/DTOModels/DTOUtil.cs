using System;
using System.Collections.Generic;
using System.Text;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.BusinessLogic
{
    public class DTOUtil
    {
        public static List<ProductDTO> MapProductDTOList(List<Product> productList)
        {
            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach (Product product in productList)
            {
                productDTOList.Add
                (
                    new ProductDTO()
                    {
                        Name = product.Name
                    }
                );
            }
            return productDTOList;
        }
        
        /*public static List<GroupStudentDTO> MapGroupStudentDTOList(List<GroupStudent> groupStudentList)
        {
            List<GroupStudentDTO> groupStudentDTOList = new List<GroupStudentDTO>();

            foreach (GroupStudent groupStudent in groupStudentList)
            {
                groupStudentDTOList.Add
                (
                    new GroupStudentDTO()
                    {
                        GroupId = groupStudent.GroupId,
                        Students = MapStudentDTOList(groupStudent.Students)
                    }
                );
            }
            return groupStudentDTOList;
        }*/
    }
}
