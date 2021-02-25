import { FormTypes } from "../types";
import { IFormAction } from "../actions/appAction";

export const appReducer = (state: any, action: IFormAction) => {
    
    switch (action.type) {
        case FormTypes.LOAD:
                return state;
            break;
        default:
            return state;
            break;
    }
}