import { ShelterTypes } from "../types"
import { IShelterCard, IShelterCardPreview } from "../interfaces/Interfaces";
import { Dispatch } from "redux";
import { showLoader, hideLoader } from "./appAction";
import axios from "axios";

export interface IFetchSheltersAction  {
    type: ShelterTypes.FETCH_SHELTERS,
    payload: IShelterCardPreview[]
}

export interface IFetchShelterAction  {
    type: ShelterTypes.FETCH_SHELTER | ShelterTypes.PUT_SHELTER,
    payload: IShelterCard
}

export type IAction = IFetchShelterAction | IFetchSheltersAction;

export const fetchShelters = () => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        const response = await fetch("https://localhost:44300/api/shelters");
        const json = await response.json();
        dispatch<IFetchSheltersAction>({type: ShelterTypes.FETCH_SHELTERS, payload: json})
        dispatch(hideLoader() as any)
    }
} 

export const fetchShelter = (id: string) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        const response = await fetch(`https://localhost:44300/api/shelters/${id}`);
        const json = await response.json();
        dispatch<IFetchShelterAction>({type: ShelterTypes.FETCH_SHELTER, payload: json})
        dispatch(hideLoader() as any)
    }
} 

export const putShelter = (id: number, data : IShelterCard) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        const json = JSON.stringify(data);
        axios.put(`https://localhost:44300/api/shelters/${id}`, data)
        .then(res => {dispatch<IFetchShelterAction>({type: ShelterTypes.PUT_SHELTER, payload: res.data})})
        dispatch(hideLoader() as any)
    }
} 