import { IShelterCard, IShelterCardPreview } from "../interfaces/Interfaces";
import { ShelterTypes } from "../types";
import { IAction } from "../actions/shelterActions";

type ShelterReducerType = {
    shelters: IShelterCardPreview[],
    currentShelter: IShelterCard
}

const initState:  ShelterReducerType = {
    shelters: [],
    currentShelter : {} as IShelterCard
}

export const shelterReducer = (state: ShelterReducerType = initState, action: IAction) => {
    
    switch (action.type) {
        case ShelterTypes.FETCH_SHELTERS:
                return {...state, shelters: action.payload};
            break;

            case ShelterTypes.FETCH_SHELTER:
                return {...state, currentShelter: action.payload};
            break;

        default:
            return state;
            break;
    }
}
