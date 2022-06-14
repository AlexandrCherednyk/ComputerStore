namespace ComputerShop.DataAccess;

internal static class StoredProcedures
{
    internal const string GET_USER = "get_user";
    internal const string ADD_USER = "add_user";
    internal const string GET_USER_LIST = "get_user_list";
    internal const string REMOVE_USER = "remove_user";
    internal const string UPDATE_USER = "update_user";

    internal const string GET_TYPE = "get_type";
    internal const string ADD_TYPE = "add_type";

    internal const string GET_MANUFACTURER = "get_manufacturer";
    internal const string ADD_MANUFACTURER = "add_manufacturer";

    internal const string ADD_PRODUCT = "add_product";
    internal const string GET_PRODUCT = "get_product";
    internal const string UPDATE_PRODUCT = "update_product";
    internal const string REMOVE_PRODUCT = "remove_product";

    internal const string GET_PRODUCT_RANGE = "get_product_range";
    internal const string PRODUCT_COUNT = "product_count";

    internal const string GET_INPUT = "get_input";
    internal const string ADD_INPUT = "add_input";
    internal const string GET_OUTPUT = "get_output";
    internal const string ADD_OUTPUT = "add_output";
}
