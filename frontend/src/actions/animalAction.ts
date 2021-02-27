import { AnimalTypes } from "../types"
import axios from "axios";
import { IAnimalCard } from "../interfaces/Interfaces";
import { Dispatch } from "redux";
import { IChangeLoading, showLoader, hideLoader } from "./appAction";


export interface IFetchAnimalAction  {
    type: AnimalTypes.FETCH_ANIMAL 
    | AnimalTypes.POST_ANIMAL 
    | AnimalTypes.PUT_ANIMAL 
    | AnimalTypes.ARCHIVE_ANIMAL 
    | AnimalTypes.DELETE_ANIMAL 
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

export const postAnimal = (animal : IAnimalCard) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        axios.post(`https://localhost:44300/api/animals`,
        {animal}
        )
        .then(res => {dispatch<IFetchAnimalAction>({type: AnimalTypes.POST_ANIMAL, payload: res.data})})

        dispatch(hideLoader() as any)
    }
} 

export const putAnimal = (animal : IAnimalCard, animalId: string) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        axios.put(`https://localhost:44300/api/animals/${animalId}`,
        {animal}
        )
        .then(res => {dispatch<IFetchAnimalAction>({type: AnimalTypes.PUT_ANIMAL, payload: res.data})})

        dispatch(hideLoader() as any)
    }
} 

export const archiveAnimal = (animalId: string) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        axios.post(`https://localhost:44300/api/animals/${animalId}/archive`)
        .then(res => {dispatch<IFetchAnimalAction>({type: AnimalTypes.ARCHIVE_ANIMAL, payload: res.data})})

        dispatch(hideLoader() as any)
    }
} 

export const deleteAnimal = (animalId: string) => {
    return async (dispatch: Dispatch)  => {
        dispatch(showLoader() as any)
        axios.delete(`https://localhost:44300/api/animals/${animalId}`)
        .then(res => {dispatch<IFetchAnimalAction>({type: AnimalTypes.DELETE_ANIMAL, payload: res.data})})

        dispatch(hideLoader() as any)
    }
} 