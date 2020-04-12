import { AnimalTypes } from "../types"
import { IAnimalCard } from "../interfaces/Interfaces";
import { Dispatch } from "redux";
import { IChangeLoading, showLoader, hideLoader } from "./appAction";


export interface IFetchAnimalAction  {
    type: AnimalTypes.FETCH_ANIMAL,
    payload: IAnimalCard
}

export type IAction = IFetchAnimalAction;

export const fetchAnimal = (shelterId : string, animalId: string) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        const response = await fetch(`https://localhost:44300/api/animals/${animalId}`);
        const json = await response.json();
        dispatch<IFetchAnimalAction>({type: AnimalTypes.FETCH_ANIMAL, payload: json})
        dispatch(hideLoader() as any)
    }
} 