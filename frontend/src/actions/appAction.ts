import { AppTypes } from "../types"
import { Dispatch } from "redux";


export interface IChangeLoading  {
    type: AppTypes,
}

export type IAction = IChangeLoading;

export const showLoader = () => {
    return async (dispatch: Dispatch)  => {
        dispatch<IChangeLoading>({type: AppTypes.SHOW_LOADER})
    }
} 

export const hideLoader = () => {
    return async (dispatch: Dispatch)  => {
        dispatch<IChangeLoading>({type: AppTypes.HIDE_LOADER})
    }
} 