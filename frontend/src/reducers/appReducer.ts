import { AppTypes } from "../types";
import { IAction } from "../actions/appAction";

type AppReducerType = {
    loading: boolean
}

const initState:  AppReducerType = {
    loading: false
}

export const appReducer = (state: AppReducerType = initState, action: IAction) => {
    
    switch (action.type) {
        case AppTypes.HIDE_LOADER:
                return {...state, loading: false};
            break;
        case AppTypes.SHOW_LOADER:
                return {...state, loading: true};
            break;
        default:
            return state;
            break;
    }
}