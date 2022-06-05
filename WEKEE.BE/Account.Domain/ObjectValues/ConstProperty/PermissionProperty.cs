﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.ConstProperty
{
    public enum PermissionProperty
    {
        NULL = 0,
        ID = 1,
        CREATE_BY = 2,
        CREATE_DATE_UTC = 3,
        UPDATE_DATE_UTC = 4,

        NAME = 5,
        DESCRIPTION = 6,
        ATOMIC_ID = 7,
        LEVEL_PERMITION = 8,
        PERMISSION_ID = 9,
        IS_ACTIVE = 10
    }

    public enum PermissionTypes
    {

    }

    public class PermissionTransform
    {
        public static string CONVERT_SQL(int key)
        {
            return (PermissionProperty)key switch
            {
                PermissionProperty.ID => "R.[id]",
                PermissionProperty.CREATE_BY => "R.[CreateBy]",
                PermissionProperty.CREATE_DATE_UTC => "R.[CreatedOnUtc]",
                PermissionProperty.UPDATE_DATE_UTC => "R.[UpdatedOnUtc]",

                PermissionProperty.NAME => "R.[name]",
                PermissionProperty.DESCRIPTION => "R.[description]",
                PermissionProperty.ATOMIC_ID => "R.[AtomicId]",
                PermissionProperty.LEVEL_PERMITION => "R.[levelPermition]",
                PermissionProperty.PERMISSION_ID => "R.[permissionId]",
                PermissionProperty.IS_ACTIVE => "R.[isActive]",

                _ => "Id",
            };
        }

        public static string CONVERT_SQL(int key, string value)
        {
            switch ((PermissionProperty)key)
            {
                case PermissionProperty.ID:
                    return $"R.[id] = {value}";
                case PermissionProperty.CREATE_BY:
                    return $"R.[CreateBy]  = {value}";
                case PermissionProperty.CREATE_DATE_UTC:
                    var DateEnd = value[(value.IndexOf("|") + 1)..];
                    var DateStart = value[..value.IndexOf("|")];

                    // check thứ tự
                    if (Convert.ToDateTime(DateStart) > Convert.ToDateTime(DateEnd))
                    {
                        (DateEnd, DateStart) = (DateStart, DateEnd);
                    }
                    // Quá khứ đến Date End
                    if (String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd))
                        return $"R.[CreatedOnUtc] <=  CONVERT(datetime, '{DateEnd}')";
                    // Từ start đến tương lai 
                    else if (!String.IsNullOrEmpty(DateStart) && String.IsNullOrEmpty(DateEnd))
                        return $"R.[CreatedOnUtc] >=  CONVERT(datetime, '{DateStart}')";
                    // Chính xác
                    else if (!String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd)
                        && Convert.ToDateTime(DateStart) == Convert.ToDateTime(DateEnd))
                        return $"(CAST(R.[CreatedOnUtc] AS Date) =  '{DateStart}')";
                    // từ start đến end
                    else if (!String.IsNullOrEmpty(DateStart) && !String.IsNullOrEmpty(DateEnd))
                        return $"(R.[CreatedOnUtc] BETWEEN CONVERT(datetime, '{DateStart}') AND CONVERT(datetime, '{DateEnd}'))";
                    // ko tìm kiếm
                    else
                        return $"R.[CreatedOnUtc] IS NOT NULL";
                case PermissionProperty.UPDATE_DATE_UTC:
                    var DateEndUpdate = value[(value.IndexOf("|") + 1)..];
                    var DateStartUpdate = value[..value.IndexOf("|")];

                    // check thứ tự
                    if (Convert.ToDateTime(DateStartUpdate) > Convert.ToDateTime(DateEndUpdate))
                    {
                        (DateEndUpdate, DateStartUpdate) = (DateStartUpdate, DateEndUpdate);
                    }
                    // Quá khứ đến Date End
                    if (String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate))
                        return $"R.[UpdatedOnUtc] <=  CONVERT(datetime, '{DateEndUpdate}')";
                    // Từ start đến tương lai 
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && String.IsNullOrEmpty(DateEndUpdate))
                        return $"R.[UpdatedOnUtc] >=  CONVERT(datetime, '{DateStartUpdate}')";
                    // Chính xác
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate)
                        && Convert.ToDateTime(DateStartUpdate) == Convert.ToDateTime(DateEndUpdate))
                        return $"(CAST(R.[UpdatedOnUtc] AS Date) =  '{DateStartUpdate}')";
                    // từ start đến end
                    else if (!String.IsNullOrEmpty(DateStartUpdate) && !String.IsNullOrEmpty(DateEndUpdate))
                        return $"(R.[UpdatedOnUtc] BETWEEN CONVERT(datetime, '{DateStartUpdate}') AND CONVERT(datetime, '{DateEndUpdate}'))";
                    // ko tìm kiếm
                    else
                        return $"R.[UpdatedOnUtc] IS NOT NULL";

                case PermissionProperty.NAME:
                    return $"R.[name] LIKE N'%{value}%'";
                case PermissionProperty.DESCRIPTION:
                    return $"R.[description] LIKE N'%{value}%'";
                case PermissionProperty.ATOMIC_ID:
                    return $"R.[AtomicId] = {value}";
                case PermissionProperty.LEVEL_PERMITION:
                    return $"R.[levelPermition] = {value}";
                case PermissionProperty.PERMISSION_ID:
                    return $"R.[permissionId] = {value}";
                case PermissionProperty.IS_ACTIVE:
                    return $"R.[isActive] = {value}";

                default: return $"R.[Id] = {value}";
            };
        }
    }
}