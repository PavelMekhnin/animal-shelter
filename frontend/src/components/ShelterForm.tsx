import { useParams as params} from "react-router-dom";
import React, { useState } from "react";
import { IShelterCard } from "../interfaces/Interfaces";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Dispatch } from "redux";
import { fetchShelter, putShelter } from "../actions/shelterActions";
import { Field, InjectedFormProps, reduxForm } from 'redux-form';


export interface IDispatchProps {
    fetch : () => void;
    put: (data: IShelterCard) => void;
}

const ShelterFormComponent = (props: IDispatchProps & InjectedFormProps<IShelterCard, IDispatchProps>) => {
    const { handleSubmit, pristine, submitting, fetch , put} = props
    const [isLoading, setIsLoading] = useState<boolean>(false);
    if (!isLoading) {
        fetch();
        setIsLoading(true);
    }

    return (
        <form onSubmit={handleSubmit(put)}>
            <div className="container">
                <div className="bodyWrapper col s6">
                    <Field component="hidden" name="id" type="text" />
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
                    <div className="input-field col s6">
                        <Field component="input" name="logoUrl" type="text" className="validate" />
                        <label htmlFor="logoUrl">Logo</label>
                    </div>
                    <div className="input-field col s6">
                        <Field component="input" name="coverUrl" type="text" className="validate" />
                        <label htmlFor="coverUrl">Cover</label>
                    </div>
                    <button type="submit" className="btn" disabled={pristine || submitting}>
                        Save
                </button>
                </div>
            </div>
        </form>
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
    fetch: () => {
        const route = params<RouteParams>();
        dispatch(fetchShelter(route.shelterid));
    },
    put: (data : IShelterCard) => {
        dispatch(putShelter(data.id, data))
    }
 })

export default connect(
    mapStateToProps,
    mapDispatchToProps as any
)(reduxForm({ form: "ShelterFormComponent", enableReinitialize: true })(ShelterFormComponent as any));
