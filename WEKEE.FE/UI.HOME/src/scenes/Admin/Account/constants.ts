enum ActionTypes {
    WATCH_PAGE_START = 'WATCH_PAGE_START',
    WATCH_PAGE_COMPLETED = 'WATCH_PAGE_COMPLETED',
    WATCH_PAGE_ERROR = 'WATCH_PAGE_ERROR',

    //#region Remove Image
    REMOVE_AVATAR_UPLOAD_START = 'REMOVE_AVATAR_UPLOAD_START',
    //#endregion

    //#region Account admin
    CREATE_ACCOUNT_ADMIN_START = 'CREATE_ACCOUNT_ADMIN_START',
    CREATE_ACCOUNT_ADMIN_COMPLETED = 'CREATE_ACCOUNT_ADMIN_COMPLETED',
    CREATE_ACCOUNT_ADMIN_ERROR = 'CREATE_ACCOUNT_ADMIN_ERROR',

    LIST_ACCOUNT_ADMIN_START = 'LIST_ACCOUNT_ADMIN_START',
    LIST_ACCOUNT_ADMIN_COMPLETED = 'LIST_ACCOUNT_ADMIN_COMPLETED',
    LIST_ACCOUNT_ADMIN_ERROR = 'LIST_ACCOUNT_ADMIN_ERROR',

    LIST_SUBJECT_ID_ACCOUNT_START = 'LIST_SUBJECT_ID_ACCOUNT_START',
    LIST_SUBJECT_ID_ACCOUNT_COMPLETED = 'LIST_SUBJECT_ID_ACCOUNT_COMPLETED',
    LIST_SUBJECT_ID_ACCOUNT_ERROR = 'LIST_SUBJECT_ID_ACCOUNT_ERROR',

    LIST_SUBJECT_ASSIGN_DTO_START = 'LIST_SUBJECT_ASSIGN_DTO_START',
    LIST_SUBJECT_ASSIGN_DTO_COMPLETED = 'LIST_SUBJECT_ASSIGN_DTO_COMPLETED',
    LIST_SUBJECT_ASSIGN_DTO_ERROR = 'LIST_SUBJECT_ASSIGN_DTO_ERROR',

    CHANGE_PERMISSION_ACCOUNT_START = 'CHANG_PERMISSION_ACCOUNT_START',
    CHANGE_PERMISSION_ACCOUNT_COMPLETED = 'CHANG_PERMISSION_ACCOUNT_COMPLETED',
    CHANGE_PERMISSION_ACCOUNT_ERROR = 'CHANG_PERMISSION_ACCOUNT_ERROR',

    DELETE_ACCOUNT_START = "DELETE_ACCOUNT_START",
    DELETE_ACCOUNT_COMPLETED = "DELETE_ACCOUNT_COMPLETED",
    DELETE_ACCOUNT_ERROR = "DELETE_ACCOUNT_ERROR",
    //#endregion

}

export default ActionTypes;