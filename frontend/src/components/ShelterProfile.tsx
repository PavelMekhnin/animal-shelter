import { useParams as params } from "react-router-dom";
import React, { Component, useEffect, useState } from "react";
import { IShelterCard } from "../interfaces/Interfaces";
import { AnimalCardList } from "./AnimalCardList";
import { ContactsBlock } from "./ContactsBlock";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect, useDispatch } from "react-redux";
import { Page404 } from "./404";
import { fetchShelter } from "../actions/shelterActions";
import { Dispatch, compose } from "redux";

export const ShelterProfile: React.FC<Props> = ({ shelter, loading, fetch }) => {
    fetch();

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
                <div className="cover-img" style={{ backgroundImage: "url(" + shelter.coverUrl + ")" }}></div>
            </div>
            <div className="row">
                <div className="col s3 grey lighten-5 center-align">
                    <img className="circle logo-img z-depth-2" src={shelter.logoUrl} alt="" />
                    <div className="row"><h5>{shelter.title}</h5></div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Адрес</span>
                            <h6>{shelter.address}</h6>
                        </div>
                    </div>
                    <div className="row"><ContactsBlock list={shelter.contacts}></ContactsBlock></div>
                </div>

                <div className="col s9">
                    <div className="row">
                        <h5>О нас</h5>
                        <p>{shelter.description}</p>
                    </div>
                    <div className="row">
                        <h5>Питомцы</h5>
                        <AnimalCardList list={shelter.animals} shelterId={shelter.id.toString()}></AnimalCardList>
                    </div>
                    <div className="row">
                        <h5>Нужды</h5>
                        <AnimalNeeds list={shelter.needs}></AnimalNeeds>
                    </div>
                </div>
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