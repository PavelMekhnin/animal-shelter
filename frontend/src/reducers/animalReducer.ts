import { IAnimalCard } from "../interfaces/Interfaces";
import { AnimalTypes } from "../types";
import { IAction } from "../actions/animalAction";

type AnimalReducerType = {
    animal: IAnimalCard
}

const initState:  AnimalReducerType = {
    animal: {} as IAnimalCard
}

export const animalReducer = (state: AnimalReducerType = initState, action: IAction) => {
    
    switch (action.type) {
        case AnimalTypes.FETCH_ANIMAL:
                return {...state, animal: action.payload};
            break;

        default:
            return state;
            break;
    }
}
