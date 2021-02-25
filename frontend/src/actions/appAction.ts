import { AppTypes, FormTypes } from "../types"
import { Dispatch } from "redux";


export interface IChangeLoading  {
    type: AppTypes,
}

export interface ILoadForm  {
    type: FormTypes,
}

export type IAction = IChangeLoading;
export type IFormAction = ILoadForm;

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

export const loadFormData = (data : any) =>{
    return (dispatch: Dispatch) => {
        dispatch({type :FormTypes.LOAD, data})
    }
}