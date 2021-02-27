import { combineReducers } from "redux";
import { shelterReducer } from "./shelterReducer";
import { animalReducer } from "./animalReducer";
import { appReducer } from "./appReducer";
import { reducer as reduxFormReducer } from 'redux-form';

export const rootReducer = combineReducers({
    shelters: shelterReducer,
    animals: animalReducer,
    app : appReducer,
    form: reduxFormReducer
});

export type AppState = ReturnType<typeof rootReducer>;