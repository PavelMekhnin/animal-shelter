import { combineReducers } from "redux";
import { shelterReducer } from "./shelterReducer";
import { animalReducer } from "./animalReducer";
import { appReducer } from "./appReducer";

export const rootReducer = combineReducers({
    shelters: shelterReducer,
    animals: animalReducer,
    app : appReducer
});

export type AppState = ReturnType<typeof rootReducer>;