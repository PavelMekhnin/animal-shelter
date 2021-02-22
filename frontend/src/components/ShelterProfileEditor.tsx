import { useParams as params, Route, Link } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { IShelterCard } from "../interfaces/Interfaces";
import { AnimalCardList } from "./AnimalCardList";
import { ContactsBlock } from "./ContactsBlock";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";
import { fetchShelter } from "../actions/shelterActions";
import { Dispatch } from "redux";
import AnimalCard from "./AnimalCard";
import { VolunteerCardList } from "./VolunteerCardList";

export const ShelterProfile: React.FC<Props> = ({ shelter, loading, fetch }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);

    if (!isLoading) {
        fetch();
        setIsLoading(true);
    }

    if (shelter.id == null) {
        if (loading == false) {
            return (
                <Page404></Page404>
            )
        }
        return (
            <div className="container">
                <div className="progress">
                    <div className="indeterminate"></div>
                </div>
            </div>
        )
    }

    return (
        <div className="container">
            <div className="row">
                <div className="input-field col s6">
                    <i className="material-icons prefix">account_circle</i>
                    <input id="title" type="text" className="validate" value={shelter.title} />
                    <label htmlFor="name">Title</label>
                </div>
            </div>
            <div className="row">
                <div className="input-field col s6">
                    <i className="material-icons prefix">description</i>
                    <input id="description" type="text" className="validate" value={shelter.description} />
                    <label htmlFor="name">Description</label>
                </div>
            </div>
            <div className="row">
                <div className="input-field col s6">
                    <i className="material-icons prefix">location_on</i>
                    <input id="address" type="text" className="validate" value={shelter.address} />
                    <label htmlFor="name">Address</label>
                </div>
            </div>
            <div className="row">
                <div className="file-field input-field">
                    <div className="btn">
                        <span>File</span>
                        <input type="file" />
                    </div>
                    <div className="file-path-wrapper">
                        <input className="file-path validate" type="text" value={shelter.logoUrl} />
                    </div>
                </div>
            </div>
            <div className="row">
                <button className="btn waves-effect waves-light" type="submit" name="action">Save</button>
            </div>
        </div>
    )
}

interface RouteParams {
    shelterid: string
}
const mapStateToProps = (state: AppState) => {
    return {
        shelter: state.shelters.currentShelter,
        loading: state.app.loading
    }
}

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
    fetch: () => {
        const route = params<RouteParams>();
        dispatch(fetchShelter(route.shelterid));
    }
})

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(ShelterProfile);