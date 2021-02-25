import { useParams as params } from "react-router-dom";
import React, { useState } from "react";
import { IShelterCard } from "../interfaces/Interfaces";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";
import { fetchShelter } from "../actions/shelterActions";
import { Dispatch } from "redux";
import Form from "redux-form";
import { Field, InjectedFormProps, reduxForm } from 'redux-form';
import { loadFormData } from "../actions/appAction";


export interface IDispatchProps {
    handleSubmit: () => any;
    load: (data: IShelterCard) => void;
}

const ShelterFormComponent = (props: IDispatchProps & InjectedFormProps<IShelterCard, IDispatchProps>) => {
    const { handleSubmit, initialValues, load } = props 

    load(initialValues as IShelterCard);

    return (
        <div className="LoginFormWrapper">
            <div className="bodyWrapper col s6">
                <div className="input-field col s6">
                    <Field component="input" name="title" type="text" className="validate" />
                    <label htmlFor="title">Title</label>
                </div>
                <div className="input-field col s6">
                    <Field component="textarea" name="description" type="textarea" className="materialize-textarea" />
                    <label htmlFor="description">Description</label>
                </div>
                <div className="input-field col s6">
                    <Field component="input" name="address" type="text" className="validate" />
                    <label htmlFor="address">Address</label>
                </div>
                <button type="submit" className="btn" >
                    Save
                </button>
            </div>
        </div>
    )
}

interface RouteParams {
    shelterid: string
}

const mapStateToProps = (state: AppState) => {
    return {
        initialValues: state.shelters.currentShelter
    }
}

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
    load: (data: IShelterCard) => {
        const route = params<RouteParams>();
        dispatch(loadFormData(data));
    }
})

export const ShelterForm = reduxForm<IShelterCard, IDispatchProps>({
    form: 'shelterForm',
    enableReinitialize : true
  })(connect(mapStateToProps, mapDispatchToProps as any)(ShelterFormComponent));