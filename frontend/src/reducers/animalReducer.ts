import { IAnimalCard } from "../interfaces/Interfaces";
import { AnimalTypes } from "../types";
import { IAction } from "../actions/animalAction";

type AnimalReducerType = {
    animals: IAnimalCard[],
    currentAnimal: IAnimalCard
}

const initState:  AnimalReducerType = {
    animals: [],
    currentAnimal: {} as IAnimalCard
}

export const animalReducer = (state: AnimalReducerType = initState, action: IAction) => {
    
    switch (action.type) {
        case AnimalTypes.POST_ANIMAL:
        case AnimalTypes.PUT_ANIMAL:
        case AnimalTypes.ARCHIVE_ANIMAL:
        case AnimalTypes.FETCH_ANIMAL:
                return {...state, currentAnimal: action.payload};
            break;

        default:
            return state;
            break;
    }
}
