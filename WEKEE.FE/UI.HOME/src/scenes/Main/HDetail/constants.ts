enum ActionTypes {
  //#region MAIN_CHECK_FEATURE
  MAIN_CHECK_FEATURE_START = 'MAIN_CHECK_FEATURE_START',
  //#endregion
  //#region  GET_CATEGORY_BREADCRUMB 
  GET_CATEGORY_BREADCRUMB_START = "GET_CATEGORY_BREADCRUMB_START",
  GET_CATEGORY_BREADCRUMB_COMPLETED = "GET_CATEGORY_BREADCRUMB_COMPLETED",
  GET_CATEGORY_BREADCRUMB_ERROR = "GET_CATEGORY_BREADCRUMB_ERROR",
  //#endregion
  //#region GET_BASIC_PRODUCT_CART
  GET_BASIC_PRODUCT_CART_START = 'GET_BASIC_PRODUCT_CART_START',
  GET_BASIC_PRODUCT_CART_COMPLETED = 'GET_BASIC_PRODUCT_CART_COMPLETED',
  GET_BASIC_PRODUCT_CART_ERROR = 'GET_BASIC_PRODUCT_CART_ERROR',
  //#endregion
  //#region GET_IMAGE_PRODUCT
  GET_IMAGE_PRODUCT_START = 'GET_IMAGE_PRODUCT_START',
  GET_IMAGE_PRODUCT_COMPLETED = 'GET_IMAGE_PRODUCT_COMPLETED',
  GET_IMAGE_PRODUCT_ERROR = 'GET_IMAGE_PRODUCT_ERROR',
  //#endregion
  //#region GET_FEATURE_CART_PRODUCT
  GET_FEATURE_CART_PRODUCT_START = 'GET_FEATURE_CART_PRODUCT_START',
  GET_FEATURE_CART_PRODUCT_COMPLETED = 'GET_FEATURE_CART_PRODUCT_COMPLETED',
  GET_FEATURE_CART_PRODUCT_ERROR = 'GET_FEATURE_CART_PRODUCT_ERROR',
  //#endregion
}

export default ActionTypes;
